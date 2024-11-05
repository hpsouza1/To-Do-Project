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
    <Modal 
      v-if="showCompletedModal" 
      :visible="showCompletedModal" 
      message="Tarefa concluída com sucesso!" 
      @close="showCompletedModal = false"
    />
    <Modal 
      v-if="showDeletedModal" 
      :visible="showDeletedModal" 
      message="Tarefa deletada com sucesso!" 
      @close="showDeletedModal = false"
    />
  </div>
</template>

<script>
import TodoItem from "./TodoItem.vue";
import Modal from "./Modal.vue";
import api from "../api/api"; 


export default {
  components: {
    TodoItem,
    Modal,
  },
  data() {
    return {
      todos: [], 
      showCompletedModal: false,
      showDeletedModal: false,
    };
  },
  methods: {
    editTodo(todo) {
      console.log("Edit:", todo);
    },
    async deleteTodo(id) {
      try {
        await api.delete(`/tarefa/${id}`);
        this.todos = this.todos.filter((t) => t.id !== id);
        console.log(`Tentando deletar a tarefa com ID: ${id}`);
        this.showDeletedModal = true;
        
        // Adicionando um pequeno atraso para garantir que o modal seja exibido
        setTimeout(() => {
          this.showDeletedModal = false; // Oculta o modal após 3 segundos
        }, 3000); 

      } catch (error) {
        console.error("Erro ao deletar a tarefa:", error);
      }
    },
    async moveToCompleted(completedTodo) {
      try {
        await api.put(`/tarefa/complete/${completedTodo.id}`);
    
        this.todos = this.todos.filter(todo => todo.id !== completedTodo.id);
        
        this.showCompletedModal = true; // Mostra o modal de tarefa concluída

        // Adicionando um pequeno atraso para garantir que o modal seja exibido
        setTimeout(() => {
          this.showCompletedModal = false; // Oculta o modal após 3 segundos
          this.$router.push({ path: `/completed-tasks` }).then(() => {
            window.location.reload();
          });
        }, 3000); 

      } catch (error) {
        console.error("Erro ao completar a tarefa:", error);
      }
    },
  },
  async mounted() {
    try {
      const response = await api.get("/tarefa"); // Ajustado para garantir a rota correta
      console.log("Response data:", response.data); // Adicionado para inspecionar o retorno da API

      this.todos = response.data.filter(todo => !todo.completed); // Filtra para mostrar apenas as não concluídas
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

<style scoped>
.todo-list {
  position: relative; 
}
</style>
