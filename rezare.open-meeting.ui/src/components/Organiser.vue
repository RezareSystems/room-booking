<template>
    <div class="hello">
        <div v-if="info" class="row pl-3 pt-3">
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import moment from 'moment'

export default {
    name: 'HelloWorld',
    data() {
        return {
            bookedTime: null,
            info: { data : { RoomName: null, Bookings: [{ StartTime: null, EndTime: null, Title: null }] }},
            dateToday: new Date().toDateString(),
            timeNow:  new Date().toLocaleString('en-NZ', { hour: 'numeric', minute: 'numeric', hour12: true }).toUpperCase()
        }
    },
    methods:{
        callApi: function () {
            axios
                .get('https://e5hqivepy9.execute-api.ap-southeast-2.amazonaws.com/dev?RoomId=kakapo&BookingDay=2019-08-27')
                .then(response => {
                    this.info = response
                    const startTime =  moment(String(response.data.Bookings[0].StartTime)).format('hh:mm A');
                    const endTime =  moment(String(response.data.Bookings[0].EndTime)).format('hh:mm A');
                    this.bookedTime = `${startTime} - ${endTime}`;
                })
        }
    },
    mounted() {
        this.callApi();
    }
}
</script>

<style scoped>
h1 {
    color: #0057A3;
    font-weight: bolder;
}
h2 {
    font-size: 1.8em;
    font-weight: bold;
    color: #0057A3;
}
h3 {
    font-size: 1.5em;
    color: #6D6E71;
}
</style>
