$(() => {
    $("#reverse").on('click', function() {
        const input = $("#input").val();
        $.get('/home/reverse', { text: input }, function(r) {
            $("#output").val(r.Word);
        });
    });
});