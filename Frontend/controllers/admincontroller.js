async function displayContracts() {
  let contracts = await getContract();

  let contractsTable = document.getElementById("getContract");

  for (let contract of contracts) {
    const {
      idContract,
      numberUser,
      numberStatus,
      quantityTourists,
      numberTour,
      dateOfConlusion,
      numberInvoice,
      sum,
      description,
    } = contract;

    const row = document.createElement("tr");

    const idContractEl = document.createElement("td");
    const numberUserEl = document.createElement("td");
    const numberStatusEl = document.createElement("td");
    const quantityTouristsEl = document.createElement("td");
    const numberTourEl = document.createElement("td");
    const dateOfConlusionEl = document.createElement("td");
    const numberInvoiceEl = document.createElement("td");
    const sumEl = document.createElement("td");
    const descriptionEl = document.createElement("td");

    idContractEl.classList.add("contract-element");
    numberUserEl.classList.add("contract-element");
    numberStatusEl.classList.add("contract-element");
    quantityTouristsEl.classList.add("contract-element");
    numberTourEl.classList.add("contract-element");
    dateOfConlusionEl.classList.add("contract-element");
    numberInvoiceEl.classList.add("contract-element");
    sumEl.classList.add("contract-element");
    descriptionEl.classList.add("contract-element");

    idContractEl.innerText = idContract;
    numberUserEl.innerText = numberUser;
    numberStatusEl.innerText = numberStatus;
    quantityTouristsEl.innerText = quantityTourists;
    numberTourEl.innerText = numberTour;
    dateOfConlusionEl.innerText = dateOfConlusion;
    numberInvoiceEl.innerText = numberInvoice;
    sumEl.innerText = sum;
    descriptionEl.innerText = description;

    row.append(
      idContractEl,
      numberUserEl,
      numberStatusEl,
      quantityTouristsEl,
      numberTourEl,
      dateOfConlusionEl,
      numberInvoiceEl,
      sumEl,
      descriptionEl
    );

    contractsTable.append(row);
  }
}

displayContracts();
