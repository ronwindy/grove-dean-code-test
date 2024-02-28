document.addEventListener("DOMContentLoaded", function() {
    function fetchCatFacts() {
        fetch("https://localhost:7247/cat/facts")
            .then(response => response.json())
            .then(catFacts => displayCatFacts(catFacts))
            .catch(error => console.log("Error fetching cat facts:", error));
    }

     function displayCatFacts(catFacts) {
        const catFactsContainer = document.getElementById("catFacts");

        if (catFacts.length === 0) {
            const noFactsMessage = document.createElement("p");
            noFactsMessage.textContent = "No cat facts to show";
            catFactsContainer.appendChild(noFactsMessage);
            return
        }

        const ul = document.createElement("ul");
        catFacts.forEach(catFact => {
            const li = document.createElement("li");
            li.textContent = catFact.text;
            ul.appendChild(li);
        });

        catFactsContainer.appendChild(ul);
    }

    fetchCatFacts();
});