namespace Content.Shared._RMC14.Attachable.Events;

[ByRefEvent]
public readonly partial record struct AttachableGetExamineDataEvent(Dictionary<byte, (AttachableModifierConditions? conditions, List<string> effectStrings)> Data);
