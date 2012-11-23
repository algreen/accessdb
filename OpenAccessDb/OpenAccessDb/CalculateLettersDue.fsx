
// Calculate whether any letters are due for a Customer depending on there order (Current SP = 1373)

// Current one does far more than allocating letters so these parts need to be re-assigned
// * If PG or OF-P on order going to a delivery address then need to change quantity to 2

// Count the number of orders
// Apply any necessary letter content
// Add contact note to this effect

let Customer = 5
let Order = 12345
let NumberOfOrders = 1 // get this from db
let IsCustomerDueALetterOnOrder = "Yes" // Check to see whether they are a Do Not Mail as well
let HaveWeAlreadyAllocatedAnotherLetterOntoThisOrder = "No" // So that we do not add say a RED Letter and a STP letter
let IsLetterWeGoingToAllocateAlreadyOnOrder = "No"
let AllocateLetter = "Dear Bob... here is your letter"
let AddContactNote = "Here is the contact note"
let HaveTheyBeenRecommendedByFriend = "Yes"
let AddContactNoteToCustomer5 = "Rec Gift Send to"
let CouldCreateOrderForOtherCustomerAtThisPoint = "Yes"
let AddContactNoteForOtherCustomer = "You have recommended the other customer who has now gone onto purchase"


// Other functions within AMO

// Allocate Free Products
//// Threshold Spends - like the Christmas Gift
//// Newsletter like additions
//// Product Guide etc additions, additional additions if there is a delivery address etc
//// Got this product, have this one added
//// Real time counters of products, change product when amount hit...



// Complimentary Gift

let FindReactionsCustomerHasHad = "Customer Reaction list is..."
let IsComplimentaryGiftActive = "Yes"
let AllocateComplimentaryGift = "True"

// Increment Total Spend

let AddOrderTotalToCustomersTotalSpend = 300M + 87.50M

// Loyalty
let IsLoyaltyRequired = "Yes"
let AllocateLoyaltyProduct = "F12345"
let IncrementLoyaltyTarget = 1000M





