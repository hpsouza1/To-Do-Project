<!-- src/components/TodoList.vue -->
<template>
  <div class="todo-list">
    <TodoItem
      v-for="todo in todos"
      :key="todo.id"
      :todo="todo"
      @edit="editTodo"
      @delete="deleteTodo"
      @complete="moveToCompleted"
    />
  </div>
</template>

<script>
import TodoItem from "./TodoItem.vue";
import api from "../api/api"; // Certifique-se de que o caminho está correto

export default {
  components: {
    TodoItem,
  },
  data() {
    return {
      todos: [], // Inicializa como um array vazio
    };
  },
  methods: {
    editTodo(todo) {
      console.log("Edit:", todo);
    },
    async deleteTodo(id) {
      try {
        await api.delete(`/tarefa/${id}`); // Chama o delete no backend
        // Atualiza a lista de tarefas no frontend removendo a tarefa deletada
        this.todos = this.todos.filter((t) => t.id !== id);
        console.log(`Tentando deletar a tarefa com ID: ${id}`);

      } catch (error) {
        console.error("Erro ao deletar a tarefa:", error);

      }
    },
    moveToCompleted(completedTodo) {
      // Atualiza a lista para esconder a tarefa concluída
      this.todos = this.todos.filter(todo => todo.id !== completedTodo.id);
      // Redireciona para a página de tarefas concluídas
      this.$router.push('/CompletedTasks');
    },
  },
  async mounted() {
    try {
      const response = await api.get("/tarefa"); // Ajustado para garantir a rota correta
      console.log("Response data:", response.data); // Adicionado para inspecionar o retorno da API

      this.todos = response.data; // Atualiza a lista de tarefas com os dados da API
      console.log("Tarefas carregadas:", this.todos);
      console.log("Resposta da API:", response.data);
      console.log("Tipo de dado:", typeof response.data);
      console.log("Estrutura dos dados:", JSON.stringify(response.data, null, 2));

    } catch (error) {
      console.error("Erro ao carregar as tarefas:", error);
    }
  },
};
</script>
