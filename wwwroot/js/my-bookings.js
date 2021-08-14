// get two date pickers
const $fromDatePicker = $('#datepicker').datepicker({
    minDate: new Date(),
    format: 'dd/mm/yyyy',
    uiLibrary: 'bootstrap4'
});
const $toDatePicker = $('#datepicker1').datepicker({
    minDate: new Date(),
    format: 'dd/mm/yyyy',
    uiLibrary: 'bootstrap4'
});

// get form
const $bookingForm = $("#booking-form");

// handle form submit
$bookingForm.on("submit", (ev) => {

    // to date should be greater than from date
    if ($toDatePicker.val() < $fromDatePicker.val()) {
        ev.preventDefault();
        alert("Checkout date should be after check-in date");
    }

    // a room size should be selected
    else if ($("#room-size-select").val() === null) {
        ev.preventDefault();
        alert("Please select a room size");
    }

    // a room type should be selected
    else if ($("#room-type-select").val() === null) {
        ev.preventDefault();
        alert("Please select a room category");
    }


});