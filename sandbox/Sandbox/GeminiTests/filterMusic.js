const hymns = [
  { id: 1, number: 2, title: "The Spirit of God", topic: "Restoration", isFavorite: false },
  { id: 2, number: 19, title: "We Thank Thee, O God, for a Prophet", topic: "Prophets", isFavorite: false },
  { id: 3, number: 85, title: "How Firm a Foundation", topic: "Faith", isFavorite: false },
  { id: 4, number: 119, title: "Come, Come, Ye Saints", topic: "Pioneers", isFavorite: false },
  { id: 5, number: 301, title: "I Am a Child of God", topic: "Children", isFavorite: false }
];

const hymnList = document.getElementById("hymn-list");

function renderHymns(hymnArray) {
    hymnList.innerHTML = "";
    hymnArray.forEach(hymn => {
        const li = document.createElement('li');
        li.innerHTML = `#${hymn.number} - ${hymn.title} <button data-id="${hymn.id}">${hymn.isFavorite ? "★ Favorite" : "☆ Add Favorite"}</button>`;
        hymnList.appendChild(li);
    });
}

renderHymns(hymns);
document.getElementById("hymn-search").addEventListener("input", filterHymnsArray)

function filterHymnsArray() {
    let userInput = document.getElementById("hymn-search");
    let filteredHymns = hymns.filter(item =>
        item.title.toLowerCase().includes(userInput.value.toLowerCase()) || item.topic.toLowerCase().includes(userInput.value.toLowerCase())
    )
    renderHymns(filteredHymns);
}

hymnList.addEventListener("click", (e) => {
    if(e.target.tagName == "BUTTON"){
        let hymnId = Number(e.target.dataset.id);
        let selectedHymn = hymns.find(hymn => hymn.id === hymnId);
        if(selectedHymn){
            selectedHymn.isFavorite = !selectedHymn.isFavorite;
        }
        filterHymnsArray();
    }
})