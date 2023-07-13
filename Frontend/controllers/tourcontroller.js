async function displayTours() {
  let tours = await getTour();

  let toursTable = document.getElementById("getTour");

  for (let tour of tours) {
    const {
      idTour,
      departureDate,
      arrivalDate,
      amountSeats,
      numberTypeTour,
      price,
      description,

      numberTourOperator,
      numberLocation,
    } = tour;

    const row = document.createElement("tr");

    const idTourEl = document.createElement("td");
    const departureDateEl = document.createElement("td");
    const arrivalDateEl = document.createElement("td");
    const amountSeatsEl = document.createElement("td");
    const numberTypeTourEl = document.createElement("td");
    const priceEl = document.createElement("td");
    const descriptionEl = document.createElement("td");

    const numberTourOperatorEl = document.createElement("td");
    const numberLocationEl = document.createElement("td");

    idTourEl.classList.add("tour1-element");
    departureDateEl.classList.add("tour1-element");
    arrivalDateEl.classList.add("tour1-element");
    amountSeatsEl.classList.add("tour1-element");
    numberTypeTourEl.classList.add("tour1-element");
    priceEl.classList.add("tour1-element");
    descriptionEl.classList.add("tour1-element");

    numberTourOperatorEl.classList.add("tour1-element");
    numberLocationEl.classList.add("tour1-element");

    idTourEl.innerText = idTour;
    departureDateEl.innerText = departureDate;
    arrivalDateEl.innerText = arrivalDate;
    amountSeatsEl.innerText = amountSeats;
    numberTypeTourEl.innerText = numberTypeTour;
    priceEl.innerText = price;
    descriptionEl.innerText = description;

    numberTourOperatorEl.innerText = numberTourOperator;
    numberLocationEl.innerText = numberLocation;

    row.append(
      idTourEl,
      departureDateEl,
      arrivalDateEl,
      amountSeatsEl,
      numberTypeTourEl,
      priceEl,
      descriptionEl,

      numberTourOperatorEl,
      numberLocationEl
    );
    toursTable.append(row);
  }
}
displayTours();
