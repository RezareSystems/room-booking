<template>
  <div class="hello">
    <div class="container">
        <div v-if="info" class="row">
            <div v-for="booking in info.data.Bookings" :key="booking.StartTime" class="col-sm">
                <div>{{ formatTime(booking.StartTime) }}</div>
                <div>Booked</div>
                <div><b>{{ booking.Title }}</b></div>
                <div>{{ booking.Organizer }}</div>
                
                <!-- <div v-for="attendee in booking.Attendees" :key="attendee">
                    <div>{{ attendee }}</div>
                </div> -->
            </div>
        </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import moment from 'moment'

export default {
    name: 'Meetings',
    props: {
    },
    methods:{
        formatTime: function(time){
            return moment(String(time)).format('hh:mm') 
        }
    },
    data () {
        return {
            info: {data : { Bookings: []}}
        }
    },
    mounted () {
        axios
            .get('https://e5hqivepy9.execute-api.ap-southeast-2.amazonaws.com/dev?RoomId=kakapo&BookingDay=2019-08-27')
            .then(response => {this.info = response})
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
img {
  height: 5em;
}
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
