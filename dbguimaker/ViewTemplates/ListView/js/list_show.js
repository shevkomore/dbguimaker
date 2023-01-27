const list_item_template = document.getElementById('list-element-template').children.item(0);
const tables_item_template = document.getElementById('table-select-template').children.item(0);

const data_list = document.getElementById("list_container");
const tables_list = document.getElementById("dropdown_show_all");
//Setting up the tables selection

tables.forEach((e, i) => {
    let item = tables_item_template.cloneNode(true);
    item.querySelector("#table_name").innerHTML = e.name;
    item.addEventListener("click", () => selectTable(i));
    tables_list.appendChild(item);
});

//Setting up the list items
selectTable(0);
function selectTable(index) {
    data_list.innerHTML = "";
    tables[index].data.forEach(items => {
        let item = list_item_template.cloneNode(true);
        //TODO
        let text = "";
        for (let i = 0; i < tables[index].structure.length; ++i) {
            text += tables[index].structure[i]+": "+items[i]+" ";
        }
        item.innerHTML = text;
        data_list.appendChild(item);
    })
}