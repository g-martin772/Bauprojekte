using System.Text;

namespace Lib.Data;
    
public enum Material {
    Clay, Sand, Concrete, Glass, Gravel, 
    Wood, Metal, Plastic, Stone, Brick, Asphalt, Marble, 
    Granite, Limestone, Slate, Copper, Steel, Aluminum, 
    Iron, Rubber, Foam, Fabric, Leather, Paper, Cardboard, 
    Bamboo, Cork, Ceramic, Porcelain, Fiberglass, CarbonFiber, 
    Kevlar, Titanium, Brass, Bronze, Pewter, Zinc, Lead, Tin, 
    Nickel, Chromium, Platinum, Gold, Silver, Diamond, Quartz, 
    Jade, Obsidian, Basalt, Pumice, Gypsum, Chalk, Salt, Sulfur, 
    Phosphorus, Silicon, Uranium, Plutonium, Mercury, Sodium, Potassium, 
    Calcium, Magnesium, Beryllium, Boron, Lithium, Helium, Neon, 
    Argon, Krypton, Xenon, Radon, Hydrogen, Oxygen, Nitrogen, 
    Carbon, Fluorine, Chlorine, Bromine, Iodine, Astatine,	
    IronOre, CopperOre, AluminumOre, GoldOre, SilverOre,
    UraniumOre, DiamondOre, QuartzOre, JadeOre, ObsidianOre,
    BasaltOre, PumiceOre, GypsumOre, ChalkOre, SaltOre, SulfurOre,
    PhosphorusOre, SiliconOre, PlutoniumOre, MercuryOre, SodiumOre,
    PotassiumOre, CalciumOre, MagnesiumOre, BerylliumOre, BoronOre,
    LithiumOre, HeliumOre, NeonOre, ArgonOre, KryptonOre, XenonOre,
    RadonOre, HydrogenOre, OxygenOre, NitrogenOre, CarbonOre,
    FluorineOre, ChlorineOre, BromineOre, IodineOre, AstatineOre,
    Coal, Oil, Gas, Biomass, Waste, Recycling, Water,
    Sewage, Telecom, Electricity, Gasoline, Diesel, JetFuel,
    Kerosene, Propane, Butane, Methane, Ethane, Ethanol,
    Methanol, Acetone, Formaldehyde, Ammonia, NitricAcid,
    SulfuricAcid, HydrochloricAcid, PhosphoricAcid, CarbonicAcid,
    CitricAcid, LacticAcid, AceticAcid, AscorbicAcid, SalicylicAcid,
    BenzoicAcid, OxalicAcid, TartaricAcid, MalicAcid, FumaricAcid,
    SuccinicAcid, GlutaricAcid, AdipicAcid, PimelicAcid, SubericAcid,
    AzelaicAcid, SebacicAcid, PhthalicAcid, IsophthalicAcid, TerephthalicAcid,
    FormicAcid, ValericAcid, CaproicAcid, CaprylicAcid, CapricAcid,
    LauricAcid, MyristicAcid, PalmiticAcid, StearicAcid, ArachidicAcid,
    BehenicAcid, LignocericAcid, CeroticAcid, MontanicAcid, MelissicAcid,
    Tiles, Timber
}

public class MaterialCollection : Dictionary<Material, int> {
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var (material, quantity) in this) {
            if (quantity > 0) {
                sb.Append($"{material}: {quantity};");
            }
        }
        return sb.ToString();
    }
}