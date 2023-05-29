namespace JumpIn.Common.Exceptions
{
    public static class ExceptionMessages
    {
        public const string RESPONSE_NULL_ERROR = "Response has returned a null value of type: {0}";
        public const string UNABLE_TO_UPDATE = "An error occurred when trying to update: {0}";
        public const string ENTITY_WITH_VALUE_NOT_FOUND = "No record with the value [{0}] for \"{1}\" could be found.";
        public const string ENTITY_WITH_ID_NOT_FOUND = "No record with the ID [{0}] could be found.";

        public static readonly string ARGUMENT_INVALID_EXCEPTION = "The argument \"{0}\" is invalid.";
        public static readonly string ARGUMENT_NULL_EXCEPTION = "The argument \"{0}\" cannot be null.";
        public static readonly string NO_MATCHING_LOOKUP_VALUE_EXCEPTION = "No matching lookup value could be found for \"{0}\"";
        public static readonly string NO_ELEMENTS_EXCEPTION = "Sequence contains no elements";
        public static readonly string NO_MATCHING_ELEMENTS_EXCEPTION = "Sequence contains no matching element";
        public static readonly string MORE_THAN_ONE_ELEMENT_EXCEPTION = "Sequence contains more than one element";

        public const string COMMAND_HANDLER_ERROR = "An error occured in command handler: {0}";
    }
}
