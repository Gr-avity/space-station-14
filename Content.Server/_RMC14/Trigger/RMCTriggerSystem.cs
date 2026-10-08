using Content.Shared._RMC14.Weapons.Ranged;
using Content.Shared.Throwing;
using Content.Shared.Trigger.Components;
using Content.Shared.Trigger.Systems;
using Content.Shared.Weapons.Ranged.Events;
using Robust.Shared.Timing;

namespace Content.Server._RMC14.Trigger;

public sealed partial class RMCTriggerSystem : EntitySystem
{
    [Dependency] private IGameTiming _timing = default!;
    [Dependency] private TriggerSystem _trigger = default!;

    public override void Initialize()
    {
        SubscribeLocalEvent<OnShootTriggerAmmoTimerComponent, AmmoShotEvent>(OnTriggerTimerAmmoShot);
        SubscribeLocalEvent<TriggerOnFixedDistanceStopComponent, ProjectileFixedDistanceStopEvent>(OnTriggerOnFixedDistanceStop);
    }

    private void OnTriggerTimerAmmoShot(Entity<OnShootTriggerAmmoTimerComponent> ent, ref AmmoShotEvent args)
    {
        foreach (var projectile in args.FiredProjectiles)
        {
            var timer = EnsureComp<TimerTriggerComponent>(projectile);
            timer.Delay = TimeSpan.FromSeconds(ent.Comp.Delay);
            timer.BeepInterval = TimeSpan.FromSeconds(ent.Comp.BeepInterval);
            timer.InitialBeepDelay = ent.Comp.InitialBeepDelay is { } delay
                ? TimeSpan.FromSeconds(delay)
                : null;
            timer.BeepSound = ent.Comp.BeepSound;
            Dirty(projectile, timer);

            _trigger.ActivateTimerTrigger((projectile, timer));
        }
    }

    private void OnTriggerOnFixedDistanceStop(Entity<TriggerOnFixedDistanceStopComponent> ent, ref ProjectileFixedDistanceStopEvent args)
    {
        var active = EnsureComp<ActiveTriggerOnThrowEndComponent>(ent);
        active.TriggerAt = _timing.CurTime + ent.Comp.Delay;
    }

    public override void Update(float frameTime)
    {
        var time = _timing.CurTime;
        var query = EntityQueryEnumerator<ActiveTriggerOnThrowEndComponent>();
        while (query.MoveNext(out var uid, out var active))
        {
            if (time < active.TriggerAt)
                continue;

            _trigger.Trigger(uid);
            if (!EntityManager.IsQueuedForDeletion(uid) && !TerminatingOrDeleted(uid))
                QueueDel(uid);
        }
    }
}
