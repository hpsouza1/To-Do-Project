<template>
    <div class="todo-details">
      <h2>{{ todo.title }}</h2>
      <p>{{ todo.subtitle }}</p>
      <button @click="goBack">Go Back</button>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        todo: { title: 'TODO TITLE', subtitle: 'TODO SUB TITLE' }
      };
    },
    methods: {
      goBack() {
        this.$router.push('/');
      }
    }
  };
  </script>
  
  <style scoped>
  .todo-details {
    padding: 20px;
    text-align: center;
  }
  </style>
  