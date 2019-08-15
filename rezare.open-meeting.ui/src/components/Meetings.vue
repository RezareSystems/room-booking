<template>
  <div class="hello">
    <div class="container booking-group">
        <div v-if="info" class="row">
            <div v-for="booking in info.data.Bookings" :key="booking.StartTime" 
            v-bind:class="{ available: booking.Available }"
            class="col-sm-4 booking">
                <div>{{ formatTime(booking.StartTime) }}</div>
                <div>{{ booking.Available? "Available": "Booked" }}</div>
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
        },
        setupBookings: function(response){
            var allBookings = [];
            var previousBooking = null;
            var previousSet = false;
            var midnightToday = new Date();
                midnightToday.setHours(0,0,0,0);

            response.data.Bookings.forEach(booking => {
                var bookingStartTime = new Date(booking.StartTime);
                var startTime = new Date();
                startTime.setHours(bookingStartTime.getHours(), bookingStartTime.getMinutes())

                if(!previousSet && startTime > midnightToday) {
                    allBookings.push({StartTime: midnightToday, EndTime: booking.StartTime, Available: true})
                    previousSet = true;
                }

                if(previousBooking){
                    if(previousBooking.EndTime < booking.StartTime) {
                        allBookings.push({StartTime: previousBooking.EndTime, EndTime: booking.StartTime, Available: true})
                    }
                }

                previousBooking = booking;
                allBookings.push(booking);
            });

            var lastBooking = allBookings[allBookings.length -1];


            var midnightTomorrow = new Date(midnightToday);
                midnightTomorrow.setDate(midnightTomorrow.getDate() + 1);

            var bookingEndTime = new Date(lastBooking.EndTime);
            var endTime = new Date();
                endTime.setHours(bookingEndTime.getHours(), bookingEndTime.getMinutes())
            // var midnightTomorrow = new Date();
            //     midnightTomorrow.addDays(1);
            //     midnightTomorrow.setHours(0,0,0,0);
            if(endTime < midnightTomorrow) {
                allBookings.push({StartTime: lastBooking.EndTime, EndTime: midnightTomorrow, Available: true})
            }

            return response.data.Bookings = allBookings;
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
            .then(response => {
                this.setupBookings(response);
                this.info = response;
            
            })
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

.booking {
    background-color: rgba(0, 86, 164, 1);
    color: white;
}

.booking.available {
    background-color: rgba(200, 228, 255, 1);
    color: black;
}

.booking-group > .row {
  overflow-x: auto;
  white-space: nowrap;
  flex-wrap: nowrap;

}
.booking-group > .row > .col-sm-4{
  display: inline-block;
  float: none;
}

/* .col-xs-4 { color: #fff; font-size: 20px; padding-bottom: 20px; padding-top: 18px; }  */
</style>
