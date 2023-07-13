async function addTour(event) {
  event.preventDefault();
  const form = event.target;
  const {
    IdTour,
    DepartureDate,
    ArrivalDate,
    AmountSeats,
    NumberTypeTour,
    Price,
    Description,

    NumberTourOperator,

    NumberLocation,
  } = form.elements;
  await insertTour(
    IdTour.value,
    DepartureDate.value,
    ArrivalDate.value,
    AmountSeats.value,
    NumberTypeTour.value,
    Price.value,
    Description.value,

    NumberTourOperator.value,
    NumberLocation.value
  );
}

document.querySelector("#add-tour-form").addEventListener("submit", addTour);
