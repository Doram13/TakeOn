<template>
  <div>
    <b-form-textarea
      id="textarea-rows"
      v-model="journals[0].content"
      @input="input"
      rows="10"
    ></b-form-textarea>
  </div>
</template>

<script>
export default {
  name: 'Journal',
  props: ['journals'],
  methods: {
    input() {
      this.$emit('journal-input');
    },
  },
};
</script>

<style scoped>

</style>
