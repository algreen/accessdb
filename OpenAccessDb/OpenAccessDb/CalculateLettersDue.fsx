
// Calculate whether any letters are due for a Customer depending on there order (Current SP = 1373)

// Current one does far more than allocating letters so these parts need to be re-assigned
// * If PG or OF-P on order going to a delivery address then need to change quantity to 2

// Count the number of orders
// Apply any necessary letter content
// Add contact note to this effect

let Customer = 5
let Order = 12345
let NumberOfOrders = 1 // get this from db
let IsDueLetterOnOrder = "No" // Check to see whether they are a Do Not Mail as well
let HaveWeAlreadyAllocatedAnotherLetterOntoThisOrder = "No" // So that we do not add say a RED Letter and a STP letter
let AllocateLetter = "Dear Bob... here is your letter"
let AddContactNote = "Here is the contact note"
let HaveTheyBeenRecommendedByFriend = "Yes"
let AddContactNoteToCustomer5 = "Rec Gift Send to"
let CouldCreateOrderForOtherCustomerAtThisPoint = "Yes"
let AddContactNoteForOtherCustomer = "You have recommended the other customer who has now gone onto purchase"


