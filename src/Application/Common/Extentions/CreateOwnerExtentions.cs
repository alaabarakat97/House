using House.Domain.Entities;
public static class CreateOwnerExtentions
{
    public static void SetOwnerSequence(this Owner owner)
    {
        owner.Apartments.Select((item, index) => new { item, index })
                                .ToList()
                                .ForEach(i => i.item.UpdateSequence(i.index + 1));
    }

//    public static string generateLicence(this Region region)
//    {
//        DateTime requestDate = DateTime.Now;

//        string RequestDateYYMMDD = requestDate.ToString("yyMMdd");
//        string RequestDateHHMMSS = requestDate.ToString("HHMMss");

//        var ExternalId = string.Format("{0}-{1}-{2}-{3}-{4}",
//            region.RegionName,
//            RequestDateYYMMDD,
//            RequestDateHHMMSS
//            );

//        return ExternalId;
//    }
}
