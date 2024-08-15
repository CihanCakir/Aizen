namespace Aizen.Core.Api.Middleware;

public enum AizenErrorCode
{
    errorCodeIsNotFound = 0,
    appTypeFailed = 1,
    porviderIdFailed = 2,
    priceMustbeGreatherThanZero = 2,
    storeOrNewCardCannotBeNull = 3,
    paymentInstrumentsCannotBeNull = 4,
    basketItemNameParameterCannotBeNull = 5,
    basketItemQuantityParameterCannotBeNull = 6,
    basketItemUnitPriceParameterCannotBeNull = 7,
    cardProcessTypeCannotBeNull = 8,
    orderIdCannotBeNull = 9,
    systemTransICannotBeNull = 10,
    totalAmountCannotEqualsZero = 11,
    customerInfoCannotBeNull = 12,
    paymentInstrumentsInfoCannotBeNull = 13,
    curruncyCannotBeNull = 14,
    itemRefundAmountCannoBeNull = 15,
    basketItemIdCannotBeNull = 16,
    itemPostAuthAmountCannoBeNull = 17,
    cardTaokenCannotBeNull = 18,
    cardUserIdCannaotBeNull = 19,
    customerIdCannotBeNull = 20,
    returnUrlCannotBeNull = 21,
    providerIdCannotBeNull = 22,
    customerIdCannotBeZero = 23,
    mailIdCannotBeZero = 24,
    userTypeIdCannotBeZero = 25,
    hostSystemCannotBeNull = 26,
    requestModelCannotBeNull = 27,
    processCouldNotFound = 28,
    referanceNoUsedBefore = 29,
    providerIdMustBeBetwennZeroToTwo = 30,
    OrderHeaderFould = 31,
    orderLoadFailedToCards = 32,
    orderDescriptionCannotBeNull = 33,
    tokenCannotBeNullorEmpty = 34,
    creditCardNotFound = 35,
    CreditCardOperationFaild = 36,
    requestNumberCannotBeNull = 37
}

public class ErrorDescriptionModel
{
    public string Language { get; set; }
    public string Description { get; set; }
}

public class ErrorViewModel
{
    public int ErrorCode { get; set; }
    public List<ErrorDescriptionModel> Errors { get; set; }
}