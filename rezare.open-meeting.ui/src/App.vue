<template>
  <div id="app">
    <Header />
    <MeetingRoom />
    <Organiser />
    <Meetings />
  </div>
</template>

<script>
import Header from './components/Header.vue';
import MeetingRoom from './components/MeetingRoom.vue';
import Organiser from './components/Organiser.vue';
import Meetings from './components/Meetings.vue';

export default {
  name: 'app',
  components: {
    Header,
    MeetingRoom,
    Organiser,
    Meetings
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
