<template>
  <div id="app">
    <Header />
    <router-view />
  </div>
</template>

<script>
import Header from './components/Header.vue';

export default {
  components: {
    Header
  }
};
</script>

<style>
body {
  font-family: 'Jost', sans-serif;
  margin: 0;
  padding: 0;
  background-color: #D6D7EF;
  width: 100%;
  height: 100vh;

}
</style>

