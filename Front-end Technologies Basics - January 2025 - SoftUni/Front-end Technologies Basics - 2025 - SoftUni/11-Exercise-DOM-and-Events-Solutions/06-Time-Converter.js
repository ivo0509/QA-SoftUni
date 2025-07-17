function attachEventsListeners() {
    let ratios = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    };

    function convert(value, unit) {
        let inDays = value / ratios[unit];
        return {
            days: inDays,
            hours: inDays * ratios.hours,
            minutes: inDays * ratios.minutes,
            seconds: inDays * ratios.seconds
        };
    }
    let daysInput = document.getElementById('days');
    let hoursInput = document.getElementById('hours');
    let minutesInput = document.getElementById('minutes');
    let secondsInput = document.getElementById('seconds');

    document.querySelector('main').addEventListener('click', onConvert);

    function onConvert(e) {
        if (e.target.tagName == 'INPUT' && e.target.type == 'button') {
            let input = e.target.parentElement.querySelector('input[type= "text"]');

            let time = convert(Number(input.value), input.id);
            daysInput.value = time.days;
            hoursInput.value = time.hours;
            minutesInput.value = time.minutes;
            secondsInput.value = time.seconds;
        }
    }
}