// src/views/RepositoryDetailsView.vue
<template>
  <div>
    <RepositoryDetails :repo="repo" />
  </div>
</template>

<script>
import RepositoryDetails from '@/components/RepositoryDetails.vue';

export default {
  name: 'RepositoryDetailsView',
  components: { RepositoryDetails },
  data() {
    return {
      repo: null,
    };
  },
  created() {
    const repoId = this.$route.params.id;
    const storedRepositories = JSON.parse(localStorage.getItem('repositories'));
    if (storedRepositories) {
      this.repo = storedRepositories.find(r => r.id === Number(repoId));
    }
  },
};
</script>
