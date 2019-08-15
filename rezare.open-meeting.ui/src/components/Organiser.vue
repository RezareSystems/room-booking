<template>
    <div class="container p-0">
        <div v-if="info" class="row pt-3 pb-5 justify-content-between align-items-end">
            <div class="card w-50 ml-3">
                <div class="row m-0 align-items-center">
                    <div class="col-4 p-0">
                        <img alt="Vue logo" src="../assets/Sailee Patel.jpg">
                    </div>
                    <div class="col-8 text-left">
                        <p class="m-0">Organiser</p>
                        <h2 class="m-0">{{ info.data.Bookings[0].Organizer }}</h2>
                        <h4 class="m-0">Project Manager</h4>
                    </div>
                </div>
                <div class="row m-0 align-items-center background">
                    <p class="m-0 pt-2 pb-1 pl-4 w-100 text-left">Attendees</p>
                    <div class="d-inline-flex pb-3 pl-4">
                        <div v-for="attendee in attendees" :key="attendee">
                            <div class="circle"><p class="align-items-center m-0 text-white h-100">{{ attendee }}</p></div>
                        </div>
                    </div>
                    <p class="pl-4">{{ attendeeCount }} Attendees</p>
                </div>
            </div>
            <div class="card mr-3 h-100">
                <div class="m-0 align-items-center text-right p-4">
                    <h2 class="m-0 pb-3">Next Meeting</h2>
                    <h4 class="m-0">{{ bookedTime }}</h4>
                    <h3 class="m-0">{{ info.data.Bookings[1].Title }}</h3>
                </div>
            </div>
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
            attendees: [],
            attendeeCount: null,
            bookedTime: null,
            info: { data : { RoomName: null, Bookings: [] }},
        }
    },
    methods:{
        callApi: function () {
            axios
                .get('https://e5hqivepy9.execute-api.ap-southeast-2.amazonaws.com/dev?RoomId=kakapo&BookingDay=2019-08-27')
                .then(response => {
                    this.info = response;
                    var initials = [];

                    const names = response.data.Bookings[0].Attendees;
                    this.attendeeCount = names.length;
                    names.forEach(name => {
                        const fullName = name.split(' ');
                        const firstName = fullName[0].toUpperCase();
                        const lastName = fullName[1].toUpperCase();
                        initials.push(firstName.charAt(0) + lastName.charAt(0));
                        
                        this.attendees = initials;

                        const startTime =  moment(String(response.data.Bookings[0].StartTime)).format('hh:mm A');
                        const endTime =  moment(String(response.data.Bookings[0].EndTime)).format('hh:mm A');
                        this.bookedTime = `${startTime} - ${endTime}`;
                    });
                })
        }
    },
    mounted() {
        this.callApi();
    }
}
</script>

<style scoped>
img {
    width: 8rem;
    height: 8rem;
    border-radius: 50%;
    padding: 1rem;
}
p {
    font-weight: bolder;
    color: #6D6E71;
    display: grid;
}
h1 {
    color: #0057A3;
    font-weight: bolder;
}
h2 {
    font-size: 1.8rem;
    font-weight: bold;
    color: #0057A3;
}
h3 {
    font-size: 1.6rem;
    font-weight: bolder;
    color: #6D6E71;
}
h4 {
    font-size: 1.3rem;
    color: #6D6E71;
}
.card {
    width: 40%;
    -webkit-box-shadow: 2px 2px 8px 0px rgba(0,0,0,0.25);
    -moz-box-shadow: 2px 2px 8px 0px rgba(0,0,0,0.25);
    box-shadow: 2px 2px 8px 0px rgba(0,0,0,0.25);
    border-radius: 0;
    border-width: 0;
}
.background {
    background-color: #fafafa;
}
.circle {
    height: 2.5rem;
    width: 2.5rem;
    border-radius: 50%;
    border: 2px solid white;
    background-color: #0057A3;
    margin-left: -0.5rem;
}
</style>
