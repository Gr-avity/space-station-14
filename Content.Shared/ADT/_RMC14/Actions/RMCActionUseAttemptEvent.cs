namespace Content.Shared._RMC14.Actions;

[ByRefEvent]
public partial record struct RMCActionUseAttemptEvent(EntityUid User, bool Cancelled = false);
