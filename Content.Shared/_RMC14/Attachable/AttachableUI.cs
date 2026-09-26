using Robust.Shared.Serialization;

namespace Content.Shared._RMC14.Attachable;

[Serializable, NetSerializable]
public sealed partial class AttachableHolderStripUserInterfaceState(Dictionary<string, (string?, bool)> attachableSlots)
    : BoundUserInterfaceState
{
    public Dictionary<string, (string?, bool)> AttachableSlots = attachableSlots;
}

[Serializable, NetSerializable]
public sealed partial class AttachableHolderChooseSlotUserInterfaceState(List<string> attachableSlots) : BoundUserInterfaceState
{
    public List<string> AttachableSlots = attachableSlots;
}

[Serializable, NetSerializable]
public sealed partial class AttachableHolderDetachMessage(string slot) : BoundUserInterfaceMessage
{
    public readonly string Slot = slot;
}

[Serializable, NetSerializable]
public sealed partial class AttachableHolderAttachToSlotMessage(string slot) : BoundUserInterfaceMessage
{
    public readonly string Slot = slot;
}

[Serializable, NetSerializable]
public enum AttachmentUI : byte
{
    StripKey,
    ChooseSlotKey,
}
