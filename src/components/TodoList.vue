<template>
    <div class="todo-list">
      <TodoItem 
        v-for="todo in todos" 
        :key="todo.id" 
        :todo="todo" 
        @edit="editTodo" 
        @delete="deleteTodo" 
        @complete="completeTodo" 
      />
    </div>
  </template>
  
  <script>
  import TodoItem from './TodoItem.vue';
  
  export default {
    components: {
      TodoItem
    },
    data() {
      return {
        todos: [
          { id: 1, title: 'TODO TITLE', subtitle: 'TODO SUB TITLE' },
          { id: 2, title: 'TODO TITLE', subtitle: 'TODO SUB TITLE' },
          { id: 3, title: 'TODO TITLE', subtitle: 'TODO SUB TITLE' }
        ]
      };
    },
    methods: {
      editTodo(todo) {
        console.log('Edit:', todo);
      },
      deleteTodo(todo) {
        this.todos = this.todos.filter(t => t.id !== todo.id);
      },
      completeTodo(todo) {
        console.log('Complete:', todo);
      }
    }
  };
  </script>
  