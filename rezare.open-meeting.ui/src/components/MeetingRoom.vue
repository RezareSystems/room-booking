<template>
    <div class="hello">
        <div class="row pl-3 pt-3">
            <div class="col-12 text-left">
                <h1 class="w-100 m-0">{{ meetingRoom }}</h1>
                <h3 class="w-100 m-0 pt-2">{{ meetingTitle }}</h3>
                <h2 class="w-100 m-0 pt-1">{{ meetingTime }}</h2>
            </div>
        </div>
    </div>
</template>

<script>
const myDate = new Date();

export default {
    name: 'HelloWorld',
    data() {
        return {
            meetingRoom: 'Kakapo Meeting Room',
            meetingTitle: 'Elaboration/Sprint Planning',
            meetingTime: '11:00 AM - 12:00 AM',
            dateToday: new Date().toDateString(),
            timeNow:  new Date().toLocaleString('en-NZ', { hour: 'numeric', minute: 'numeric', hour12: true }).toUpperCase()
        }
    },
    methods:{
        callApi: function () {
            axios
                .get('https://e5hqivepy9.execute-api.ap-southeast-2.amazonaws.com/dev?RoomId=kakapo&BookingDay=2019-08-27')
                .then(response => {this.info = response})
        }
    },
    mounted() {
        this.callApi();
    }
}
</script>

<style scoped>
img {
    height: 5em;
}
h1 {
    color: #0057A3;
    font-weight: bolder;
}
h2 {
    font-size: 2em;
    font-weight: bold;
    color: #0057A3;
}
h3 {
    margin: 40px 0 0;
}
h4 {
    font-size: 1em;
    color: #6D6E71;
    padding-right: 1em;
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
