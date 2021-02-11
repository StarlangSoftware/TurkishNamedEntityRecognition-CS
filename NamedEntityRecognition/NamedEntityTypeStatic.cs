namespace NamedEntityRecognition
{
    public static class NamedEntityTypeStatic
    {
        /**
         * <summary>Static function to convert a string entity type to {@link NamedEntityType} type.</summary>
         * <param name="entityType">Entity type in string form</param>
         * <returns>Entity type in {@link NamedEntityType} form</returns>
         */
        public static NamedEntityType GetNamedEntityType(string entityType)
        {
            switch (entityType.ToUpper())
            {
                case "PERSON":
                    return NamedEntityType.PERSON;
                case "LOCATION":
                    return NamedEntityType.LOCATION;
                case "ORGANIZATION":
                    return NamedEntityType.ORGANIZATION;
                case "TIME":
                    return NamedEntityType.TIME;
                case "MONEY":
                    return NamedEntityType.MONEY;
                default:
                    return NamedEntityType.NONE;
            }
        }

        /**
        * <summary>Static function to convert a {@link NamedEntityType} to string form.</summary>
        * <param name="entityType">Entity type in {@link NamedEntityType} form</param>
        * <returns>Entity type in string form</returns>
        */
        public static string GetNamedEntityType(NamedEntityType entityType)
        {
            switch (entityType)
            {
                case NamedEntityType.PERSON:
                    return "PERSON";
                case NamedEntityType.LOCATION:
                    return "LOCATION";
                case NamedEntityType.ORGANIZATION:
                    return "ORGANIZATION";
                case NamedEntityType.TIME:
                    return "TIME";
                case NamedEntityType.MONEY:
                    return "MONEY";
                default:
                    return "NONE";
            }
        }
    }
}