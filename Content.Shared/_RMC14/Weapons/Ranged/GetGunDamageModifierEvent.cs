using Content.Shared.FixedPoint;

namespace Content.Shared._RMC14.Weapons.Ranged;

[ByRefEvent]
public partial record struct GetGunDamageModifierEvent(FixedPoint2 Multiplier);
