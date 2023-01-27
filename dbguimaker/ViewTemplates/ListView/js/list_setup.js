class Data {
    constructor(name, structure, table) {
        this.name = name;
        this.structure = structure;
        this.data = table;
    }
    put(item) {
        this.table.push(item);
    }
    get(index, item) {
         return elements[index][this.structure.find(e => e === item)];
    }
}
const tables = [];