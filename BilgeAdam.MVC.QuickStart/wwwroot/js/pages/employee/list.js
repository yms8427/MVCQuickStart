var instance = {
    data: function () {
        return {
            title: "Çalışan Listesi",
            employees: [],
            newEmployee: {
                firstName: "",
                lastName: "",
                birthDate: null,
                country: "",
                city: "",
                phone: ""
            }
        };
    },
    mounted: function () {
        var self = this;
        axios.get("/employee/getemployees")
            .then(function (response) {
                loadData(self.employees, response.data);
            });
    },
    methods: {
        add() {
            $("#newEmployee").modal();
        },
        save() {
            var self = this;
            var data = {};
            Object.assign(data, this.newEmployee);
            data.birthDate = new Date(this.newEmployee.birthDate);
            axios.post("/employee/save", data)
                .then(function (response) {
                    addRow(self.employees, response.data);
                    $("#newEmployee").modal("hide");
                })
            this.newEmployee = {
                firstName: "",
                lastName: "",
                birthDate: null,
                country: "",
                city: "",
                phone: ""
            }
        }
    }
};
var audio = new Audio('/audio/bell.mp3');
function loadData(array, data) {
    var length = data.length;
    var index = 0;
    var timer = setInterval(function () {
        if (index === length) {
            clearInterval(timer);
            return;
        }
        addRow(array, data[index]);
        index++;
    }, 100);
}

function addRow(array, data) {
    audio.currentTime = 0;
    audio.play();
    array.push(data);
}

Vue.createApp(instance).mount("#app");