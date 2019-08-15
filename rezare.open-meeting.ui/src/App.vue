<template>
  <div id="app">
    <Header />
    <Meetings />
  </div>
</template>

<script>
import Header from './components/Header.vue';
import Meetings from './components/Meetings.vue';

export default {
  name: 'app',
  components: {
    Header,
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
