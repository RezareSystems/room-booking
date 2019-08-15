<template>
  <div id="app">
    <Header />
    <MeetingRoom />
    <Organiser />
    <Meetings id="meetings"/>
    <date-picker-modal />
  </div>
</template>

<script>
import Header from './components/Header.vue';
import MeetingRoom from './components/MeetingRoom.vue';
import Organiser from './components/Organiser.vue';
import Meetings from './components/Meetings.vue';
import Vue from 'vue';
import { setupCalendar, Calendar } from 'v-calendar'
import 'v-calendar/lib/v-calendar.min.css';
import DatePickerModal from './components/DatePickerModal.vue'

// Remember to setup calendar (passing in defaults if needed)
setupCalendar(Vue, {
  componentPrefix: 'vc'
});
Vue.component('v-calendar', Calendar);

export default {
  name: 'app',
  components: {
    Header,
    MeetingRoom,
    Organiser,
    Meetings,
    DatePickerModal
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 1.5rem;
}

</style>
