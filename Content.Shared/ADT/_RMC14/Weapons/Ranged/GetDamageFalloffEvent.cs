using Content.Shared.FixedPoint;

namespace Content.Shared._RMC14.Weapons.Ranged;

[ByRefEvent]
public partial record struct GetDamageFalloffEvent(
    FixedPoint2 FalloffMultiplier
);
