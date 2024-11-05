<template>
  <div class="completed-tasks">
    <Header title="Completed Tasks" :showBackButton="true" />
    <div class="conteudo">
      <div v-if="completedTasks.length > 0">
        <!-- Passa isCompletedView como true para ocultar os botões -->
        <TodoItem v-for="task in completedTasks" :key="task.id" :todo="task" :isCompletedView="true" />
      </div>
      <p v-else>No completed tasks available.</p>
    </div>
  </div>
</template>

<script>
import Header from '@/components/Header.vue'
import TodoItem from '@/components/TodoItem.vue'
import api from '../api/api'

export default {
  components: {
    Header,
    TodoItem
  },
  data() {
    return {
      completedTasks: []
    };
  },
  async created() {
    try {
      const response = await api.get('/tarefa/completed');
      this.completedTasks = response.data;
    } catch (error) {
      console.error('Erro ao carregar tarefas concluídas:', error);
    }
  }
};
</script>

<style scoped>
.completed-tasks {
  overflow-x: hidden;
  overflow-y: scroll;
}

.conteudo {
  padding: 0px;
  display: flex;
  justify-content: center;

  align-items: center;
}
</style>
