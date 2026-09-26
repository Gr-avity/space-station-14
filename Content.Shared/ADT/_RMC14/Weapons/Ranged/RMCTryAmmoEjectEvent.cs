
namespace Content.Shared._RMC14.Weapons.Ranged;

[ByRefEvent]
public partial record struct RMCTryAmmoEjectEvent(
    EntityUid User,
    bool Cancelled
);
