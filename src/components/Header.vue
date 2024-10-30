<!-- src/components/Header.vue -->
<template>
  <header class="header">
    <button v-if="showBackButton" @click="$router.back()" class="back-button">←</button>
    <h1>{{ title }}</h1>
  </header>
</template>

<script>
export default {
  props: {
    title: {
      type: String,
      default: 'TODO APP'
    },
    showBackButton: {
      type: Boolean,
      default: false
    }
  }
};
</script>

<style scoped>
.header {
  background-color: #9395D3;
  padding: 20px;
  display: flex;
  align-items: center;
  color: white;
  margin-bottom: 30px;
}

.calendar-button img {
  width: 34px;
}

.calendar-button {
  background: none;
  border: none;
}

.back-button {
  background: none;
  border: none;
  font-size: 24px;
  color: white;
  cursor: pointer;
  margin-right: 50px;
}
</style>
