async function getContract() {
  const response = await fetch("https://localhost:7187/api/Contracts", {
    method: "GET",
  });
  const result = await response.json();
  return result;
}
