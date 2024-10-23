<template>
    <div class="home">
      <TodoList />
      <button class="add-todo" @click="addTodo">+</button>
    </div>
  </template>
  
  <script>
  import TodoList from '@/components/TodoList.vue';
  
  export default {
    components: {
      TodoList
    },
    methods: {
      addTodo() {
        console.log('Adding new todo...');
      }
    }
  };
  </script>
  
  <style scoped>
  .add-todo {
    position: fixed;
    bottom: 20px;
    right: 20px;
    background-color: #9f94d2;
    color: white;
    border: none;
    border-radius: 50%;
    width: 50px;
    height: 50px;
    font-size: 24px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.2);
  }
  </style>
  