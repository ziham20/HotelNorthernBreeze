// get signup form
const signUpForm = $("#signup-form");

// handle form submission
signUpForm.on("submit", (ev) => {
    // check passwords match
    if ($("#password").val() !== $("#confirm-password").val()) {
        ev.preventDefault();
        alert("Two passwords do not match");
    }
})