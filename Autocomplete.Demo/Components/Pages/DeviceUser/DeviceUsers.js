$('#userTable').on('click', 'tbody tr', function(event) {
    $(this).addClass('highlight').siblings().removeClass('highlight');
    const userId = $(this).attr('data-id');
    $(window).trigger('UserSelected', userId);
});