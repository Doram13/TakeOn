<template>
  <div class="container-fluid">
    <b-input class="bg-dark text-light align-content-center" v-for="answer in answers"
         :key="answer.id"
         v-model="answer.content"
         @input="answerInput(answer)">
    </b-input>
  </div>
</template>

<script>
export default {
  name: 'Answers',
  props: ['answers'],
  methods: {
    answerInput(answer) {
      this.$emit('answer-input', answer);
    },
  },
};
</script>

<style scoped>

</style>
