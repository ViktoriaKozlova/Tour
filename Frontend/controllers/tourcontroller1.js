async function displayTours() {
  let tours = await getTourId(1);

  let toursTable = document.getElementById("getTour");
  let toursTable1 = document.getElementById("getTour1");
  let toursTable2 = document.getElementById("getTour2");
  let toursTable3 = document.getElementById("getTour3");
  let toursTable4 = document.getElementById("getTour4");
  const {
    departureDate,
    arrivalDate,
    amountSeats,

    price,
    description,
  } = tours;

  const row = document.createElement("p");
  const row1 = document.createElement("p");
  const row2 = document.createElement("p");
  const row3 = document.createElement("p");
  const row4 = document.createElement("p");

  const departureDateEl = document.createElement("p");
  const arrivalDateEl = document.createElement("p");
  const amountSeatsEl = document.createElement("p");
  const priceEl = document.createElement("p");
  const descriptionEl = document.createElement("p");

  departureDateEl.classList.add("tour-element");
  arrivalDateEl.classList.add("tour-element");
  amountSeatsEl.classList.add("tour-element");
  priceEl.classList.add("tour-element");
  descriptionEl.classList.add("tour-element");

  departureDateEl.innerText = departureDate;
  arrivalDateEl.innerText = arrivalDate;
  amountSeatsEl.innerText = amountSeats;
  priceEl.innerText = price;
  descriptionEl.innerText = description;

  row.append(departureDateEl);
  row1.append(arrivalDateEl);

  row2.append(amountSeatsEl);

  row3.append(priceEl);

  row4.append(descriptionEl);

  toursTable.append(row);
  toursTable1.append(row1);
  toursTable2.append(row2);
  toursTable3.append(row3);
  toursTable4.append(row4);
}

displayTours();
