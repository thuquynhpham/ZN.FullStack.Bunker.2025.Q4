<template>
  <div class="vessel-list">
    <div class="header">
      <h1>Vessel Management</h1>
      <div class="header-actions">
        <router-link to="/vessels/create" class="btn btn-primary">
          <i class="icon">+</i> Add New Vessel
        </router-link>
      </div>
    </div>

    <!-- Search and Filters -->
    <div class="filters-section">
      <div class="search-bar">
        <input 
          v-model="searchQuery.name" 
          type="text" 
          placeholder="Search by vessel name..."
          class="search-input"
        />
        <input 
          v-model="searchQuery.imo" 
          type="text" 
          placeholder="Search by IMO..."
          class="search-input"
        />
        <select v-model="searchQuery.status" class="filter-select">
          <option value="">All Status</option>
          <option value="Active">Active</option>
          <option value="Inactive">Inactive</option>
          <option value="Maintenance">Maintenance</option>
        </select>
        <button @click="applyFilters" class="btn btn-secondary">Search</button>
        <button @click="clearFilters" class="btn btn-outline">Clear</button>
      </div>
    </div>

    <!-- Loading State -->
    <div v-if="isLoading" class="loading">
      <div class="spinner"></div>
      <p>Loading vessels...</p>
    </div>

    <!-- Error State -->
    <div v-else-if="hasError" class="error">
      <p>{{ error }}</p>
      <button @click="fetchVessels" class="btn btn-primary">Retry</button>
    </div>

    <!-- Vessels Table -->
    <div v-else class="table-container">
      <table class="vessels-table">
        <thead>
          <tr>
            <th>Name</th>
            <th>IMO</th>
            <th>Type</th>
            <th>Flag</th>
            <th>Status</th>
            <th>Year Built</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="vessel in vessels" :key="vessel.id" class="vessel-row">
            <td>{{ vessel.name }}</td>
            <td>{{ vessel.imo }}</td>
            <td>{{ vessel.vesselType }}</td>
            <td>{{ vessel.flag }}</td>
            <td>
              <span :class="['status-badge', `status-${vessel.status.toLowerCase()}`]">
                {{ vessel.status }}
              </span>
            </td>
            <td>{{ vessel.yearBuilt || 'N/A' }}</td>
            <td class="actions">
              <router-link :to="`/vessels/${vessel.id}`" class="btn btn-sm btn-info">
                View
              </router-link>
              <router-link :to="`/vessels/${vessel.id}/edit`" class="btn btn-sm btn-warning">
                Edit
              </router-link>
              <button @click="confirmDelete(vessel)" class="btn btn-sm btn-danger">
                Delete
              </button>
            </td>
          </tr>
        </tbody>
      </table>

      <!-- Empty State -->
      <div v-if="!hasVessels && !isLoading" class="empty-state">
        <p>No vessels found. <router-link to="/vessels/create">Create your first vessel</router-link></p>
      </div>
    </div>

    <!-- Pagination -->
    <div v-if="hasVessels" class="pagination">
      <button 
        @click="goToPage(pagination.pageNumber - 1)" 
        :disabled="pagination.pageNumber <= 1"
        class="btn btn-outline"
      >
        Previous
      </button>
      <span class="page-info">
        Page {{ pagination.pageNumber }} of {{ pagination.totalPages }}
        ({{ pagination.totalCount }} total vessels)
      </span>
      <button 
        @click="goToPage(pagination.pageNumber + 1)" 
        :disabled="pagination.pageNumber >= pagination.totalPages"
        class="btn btn-outline"
      >
        Next
      </button>
    </div>

    <!-- Delete Confirmation Modal -->
    <div v-if="showDeleteModal" class="modal-overlay" @click="closeDeleteModal">
      <div class="modal" @click.stop>
        <h3>Confirm Delete</h3>
        <p>Are you sure you want to delete vessel "{{ vesselToDelete?.name }}"?</p>
        <div class="modal-actions">
          <button @click="closeDeleteModal" class="btn btn-outline">Cancel</button>
          <button @click="deleteVessel" class="btn btn-danger">Delete</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed } from 'vue'
import { useVesselStore } from '@/stores/vesselStore'
import type { Vessel, VesselListQuery } from '@/types'

const vesselStore = useVesselStore()

// Reactive data
const searchQuery = ref<VesselListQuery>({
  pageNumber: 1,
  pageSize: 10
})

const showDeleteModal = ref(false)
const vesselToDelete = ref<Vessel | null>(null)

// Computed properties
const vessels = computed(() => vesselStore.vessels)
const isLoading = computed(() => vesselStore.isLoading)
const hasError = computed(() => vesselStore.hasError)
const error = computed(() => vesselStore.error)
const hasVessels = computed(() => vesselStore.hasVessels)
const pagination = computed(() => vesselStore.pagination)

// Methods
const fetchVessels = async () => {
  await vesselStore.fetchVessels(searchQuery.value)
}

const applyFilters = () => {
  searchQuery.value.pageNumber = 1
  fetchVessels()
}

const clearFilters = () => {
  searchQuery.value = {
    pageNumber: 1,
    pageSize: 10
  }
  fetchVessels()
}

const goToPage = (page: number) => {
  if (page >= 1 && page <= pagination.value.totalPages) {
    searchQuery.value.pageNumber = page
    fetchVessels()
  }
}

const confirmDelete = (vessel: Vessel) => {
  vesselToDelete.value = vessel
  showDeleteModal.value = true
}

const closeDeleteModal = () => {
  showDeleteModal.value = false
  vesselToDelete.value = null
}

const deleteVessel = async () => {
  if (vesselToDelete.value) {
    try {
      await vesselStore.deleteVessel(vesselToDelete.value.id)
      closeDeleteModal()
      // Refresh the list
      await fetchVessels()
    } catch (error) {
      console.error('Error deleting vessel:', error)
    }
  }
}

// Lifecycle
onMounted(() => {
  fetchVessels()
})
</script>

<style scoped>
.vessel-list {
  max-width: 1200px;
  margin: 0 auto;
  padding: 2rem;
}

.header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 2rem;
}

.header h1 {
  color: #2c3e50;
  margin: 0;
}

.filters-section {
  background: white;
  padding: 1.5rem;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
  margin-bottom: 2rem;
}

.search-bar {
  display: flex;
  gap: 1rem;
  flex-wrap: wrap;
  align-items: center;
}

.search-input, .filter-select {
  padding: 0.5rem;
  border: 1px solid #ddd;
  border-radius: 4px;
  flex: 1;
  min-width: 200px;
}

.btn {
  padding: 0.5rem 1rem;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  text-decoration: none;
  display: inline-block;
  font-weight: 500;
  transition: all 0.3s ease;
}

.btn-primary {
  background-color: #3498db;
  color: white;
}

.btn-secondary {
  background-color: #95a5a6;
  color: white;
}

.btn-outline {
  background-color: transparent;
  color: #3498db;
  border: 1px solid #3498db;
}

.btn-info {
  background-color: #17a2b8;
  color: white;
}

.btn-warning {
  background-color: #ffc107;
  color: #212529;
}

.btn-danger {
  background-color: #dc3545;
  color: white;
}

.btn-sm {
  padding: 0.25rem 0.5rem;
  font-size: 0.875rem;
}

.loading, .error, .empty-state {
  text-align: center;
  padding: 3rem;
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}

.spinner {
  width: 40px;
  height: 40px;
  border: 4px solid #f3f3f3;
  border-top: 4px solid #3498db;
  border-radius: 50%;
  animation: spin 1s linear infinite;
  margin: 0 auto 1rem;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}

.table-container {
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
  overflow: hidden;
}

.vessels-table {
  width: 100%;
  border-collapse: collapse;
}

.vessels-table th,
.vessels-table td {
  padding: 1rem;
  text-align: left;
  border-bottom: 1px solid #eee;
}

.vessels-table th {
  background-color: #f8f9fa;
  font-weight: 600;
  color: #2c3e50;
}

.vessel-row:hover {
  background-color: #f8f9fa;
}

.status-badge {
  padding: 0.25rem 0.5rem;
  border-radius: 12px;
  font-size: 0.75rem;
  font-weight: 500;
  text-transform: uppercase;
}

.status-active {
  background-color: #d4edda;
  color: #155724;
}

.status-inactive {
  background-color: #f8d7da;
  color: #721c24;
}

.status-maintenance {
  background-color: #fff3cd;
  color: #856404;
}

.actions {
  display: flex;
  gap: 0.5rem;
}

.pagination {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 1rem;
  margin-top: 2rem;
  padding: 1rem;
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}

.page-info {
  color: #666;
  font-weight: 500;
}

.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0,0,0,0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.modal {
  background: white;
  padding: 2rem;
  border-radius: 8px;
  box-shadow: 0 4px 6px rgba(0,0,0,0.1);
  max-width: 400px;
  width: 90%;
}

.modal h3 {
  margin-top: 0;
  color: #2c3e50;
}

.modal-actions {
  display: flex;
  gap: 1rem;
  justify-content: flex-end;
  margin-top: 1.5rem;
}
</style>
