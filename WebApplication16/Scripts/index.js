$(() => {

    const addPersonToTable = person => {
        $("#people-table").append(`<tr>
                                        <td>${person.FirstName}</td>
                                        <td>${person.LastName}</td>
                                        <td>${person.Age}</td>
                                        </tr>`);
    }

    $("#add-person").on('click', function () {
        $.get('/home/GetFakePerson', { minAge: 10, maxAge: 20 }, function (person) {
            addPersonToTable(person);
        });
    });

    $("#add-people").on('click', function () {
        const size = $("#size").val();
        $.post('/home/GetPeople', { size }, function (people) {
            //people.forEach(person => addPersonToTable(person));
            people.forEach(addPersonToTable);
        });
    });
});





