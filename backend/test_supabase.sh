#!/bin/bash
# Test script pentru conexiunea Supabase

echo "=========================================="
echo "TEST CONEXIUNE SUPABASE - Backend .NET"
echo "=========================================="
echo ""

cd /Users/mihai/Desktop/Craiova/CraiovaHackaton_Back/backend/backend

echo "1. Verificare pachete instalate..."
dotnet list package | grep -E "(Npgsql|EntityFramework)" || echo "Pachete găsite!"
echo ""

echo "2. Verificare user-secrets..."
dotnet user-secrets list | grep "ConnectionStrings" || echo "Connection string configurat!"
echo ""

echo "3. Build proiect..."
dotnet build --no-restore > /dev/null 2>&1
if [ $? -eq 0 ]; then
    echo "✅ Build reușit!"
else
    echo "❌ Build eșuat - rulează: dotnet build"
    exit 1
fi
echo ""

echo "4. Oprire servere vechi..."
pids=$(lsof -tiTCP:5092 -sTCP:LISTEN 2>/dev/null)
if [ -n "$pids" ]; then
    echo "Oprire PID: $pids"
    kill $pids 2>/dev/null || true
    sleep 2
fi
echo ""

echo "5. Pornire server (va rula 15 secunde)..."
echo "Server pornește pe http://localhost:5092"
echo ""

# Pornește serverul în background și salvează PID
dotnet run > server.log 2>&1 &
SERVER_PID=$!
echo "Server PID: $SERVER_PID"

# Așteaptă ca serverul să pornească
echo "Aștept pornirea serverului..."
sleep 8

echo ""
echo "6. Testare endpoints..."
echo ""

# Test endpoint simplu (fără DB)
echo "Test 1: GET /test (fără DB)"
curl -s http://localhost:5092/test 2>&1 | head -3
echo ""
echo ""

# Test endpoint cu DB
echo "Test 2: GET /api/scaffold/cars (cu Supabase DB)"
curl -s http://localhost:5092/api/scaffold/cars 2>&1 | head -10
echo ""
echo ""

echo "Test 3: GET /api/scaffold/users (cu Supabase DB)"
curl -s http://localhost:5092/api/scaffold/users 2>&1 | head -10
echo ""

# Oprește serverul
echo ""
echo "7. Oprire server..."
kill $SERVER_PID 2>/dev/null || true
sleep 1

echo ""
echo "=========================================="
echo "LOG COMPLET SERVER (ultimele 30 linii):"
echo "=========================================="
tail -30 server.log 2>/dev/null || echo "Fișier log nu există"
echo ""

echo "=========================================="
echo "TEST FINALIZAT!"
echo "=========================================="
echo ""
echo "Comenzi utile:"
echo "  - Pornire server: cd backend/backend && dotnet run"
echo "  - Oprire server: lsof -tiTCP:5092 | xargs kill"
echo "  - Vezi logs: tail -f server.log"
echo ""

