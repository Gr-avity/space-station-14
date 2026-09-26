namespace Content.Shared._RMC14.Attachable.Events;

[ByRefEvent]
public readonly partial record struct AttachableHolderAttachablesAlteredEvent(
    EntityUid Attachable,
    string SlotId,
    AttachableAlteredType Alteration
);
