async function getTour() {
  const response = await fetch("https://localhost:7187/api/Tours", {
    method: "GET",
  });
  const result = await response.json();
  return result;
}

async function getTourId(id) {
  const response = await fetch(`https://localhost:7187/api/Tours/${id}`, {
    method: "GET",
  });
  const result = await response.json();
  return result;
}

async function insertTour(
  IdTour,
  DepartureDate,
  ArrivalDate,
  AmountSeats,
  NumberTypeTour,
  Price,
  Description,
  NumberLocation,
  Remark,
  NumberTourOperator,
  number_status
) {
  try {
    const body = JSON.stringify({
      IdTour,
      DepartureDate,
      ArrivalDate,
      AmountSeats,
      NumberTypeTour,
      Price,
      Description,
      NumberLocation,
      Remark,
      NumberTourOperator,
      number_status,
    });
    const response = await fetch("https://localhost:7187/api/Tours", {
      method: "POST",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log(" added!");
  } catch (error) {
    console.log(error.message);
  }
}

async function newversionTour(
  IdTour,
  DepartureDate,
  ArrivalDate,
  AmountSeats,
  NumberTypeTour,
  Price,
  Description,
  NumberLocation,
  Remark,
  NumberTourOperator,
  number_status
) {
  try {
    const body = JSON.stringify({
      IdTour,
      DepartureDate,
      ArrivalDate,
      AmountSeats,
      NumberTypeTour,
      Price,
      Description,
      NumberLocation,
      Remark,
      NumberTourOperator,
      number_status,
    });
    const response = await fetch("https://localhost:7187/api/Tours", {
      method: "PUT",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
  } catch (error) {
    console.log(error.message);
  }
}

async function deleteTour(id) {
  try {
    const response = await fetch(`https://localhost:7187/api/Tours/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Error");
    }
  } catch (error) {
    console.log(error.message);
  }
}
