const appointmentConnection = new signalR.HubConnectionBuilder()
    .withUrl("/appointmentHub")
    .build();

appointmentConnection.on("ReceiveAppointment", function (message) {
location.reload(); 
});
appointmentConnection.on("ReceiveAppointmentUpdate", function (message) {
    location.reload();
});
appointmentConnection.start().catch(function (err) {
    console.error(err.toString());
});
