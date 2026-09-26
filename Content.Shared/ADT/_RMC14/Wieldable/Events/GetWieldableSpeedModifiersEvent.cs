
namespace Content.Shared._RMC14.Wieldable.Events;

[ByRefEvent]
public partial record struct GetWieldableSpeedModifiersEvent(
    float Walk,
    float Sprint
);
