using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.Models.MyFlood;

public enum ContentsCostValueType
{
    [Display(Name = "Actual Cash Value")]
    ActualCashValue,
    [Display(Name = "Replacement Cost Value")]
    ReplacementCostValue
}

public enum ResidentialOccupancyType
{
    Primary,
    Secondary,
    Seasonal,
    Tenanted,
    Vacant,
    [Display(Name = "Course of Construction")]
    CourseOfConstruction,
    [Display(Name = "Vacant Renovation")]
    VacantRenovation
}

public enum ResidentialConstructionType
{
    [Display(Name = "Brick Veneer")]
    BrickVeneer,
    EIFS,
    Frame,
    Log,
    Masonry,
    Stucco,
    Asbestos
}

public enum AttachedGarageType
{
    Finished,
    Unfinished,
    None
}

public enum BasementType
{
    Finished,
    Unfinished,
    None
}

public enum FoundationType
{
    [Display(Name = "Piers/Posts/Pilings")]
    PiersPostsPilings,
    [Display(Name = "Reinforced Shear Walls")]
    ReinforcedShearWalls,
    [Display(Name = "Solid Foundation Walls")]
    SolidFoundationWalls,
    [Display(Name = "Foundation Wall")]
    FoundationWall,
    [Display(Name = "Slab On Fill")]
    SlabOnFill,
    [Display(Name = "Slab On Grade")]
    SlabOnGrade
}

public enum AdditionalFoundationType
{
    [Display(Name = "Finished Enclosure Full")]
    FinishedEnclosureFull,
    [Display(Name = "Finished Enclosure Partial")]
    FinishedEnclosurePartial,
    [Display(Name = "Unfinished Enclosure Full")]
    UnfinishedEnclosureFull,
    [Display(Name = "Unfinished Enclosure Partial")]
    UnfinishedEnclosurePartial,
    [Display(Name = "Finished Crawlspace")]
    FinishedCrawlspace,
    [Display(Name = "Unfinished Crawlspace")]
    UnfinishedCrawlspace,
    None
}

public enum BuildingOverWaterType
{
    Entirely,
    Partially,
    No
}