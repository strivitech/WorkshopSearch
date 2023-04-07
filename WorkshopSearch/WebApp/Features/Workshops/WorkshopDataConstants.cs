namespace WebApp.Features.Workshops;

public static class WorkshopDataConstants
{
    public static class Filter
    {
        public const int MinAgeDefaultValue = MinAgeMinValue;
        public const int MaxAgeDefaultValue = MaxAgeMaxValue;
        public const int MinPriceDefaultValue = MinPriceMinValue;
        public const int MaxPriceDefaultValue = MaxPriceMaxValue;
        
        public const int MaxTextLength = 100;
        public const int MinCategoryId = 1;
        public const int MaxCategoryId = 3;
        public const int MinPriceMinValue = 0;
        public const int MinPriceMaxValue = 100000;
        public const int MaxPriceMinValue = 0;
        public const int MaxPriceMaxValue = 100000;
        public const int MinAgeMinValue = 0;
        public const int MinAgeMaxValue = 100;
        public const int MaxAgeMinValue = 0;
        public const int MaxAgeMaxValue = 100;
        public const int MaxLengthWorkingDaysArray = 7;
    }
}