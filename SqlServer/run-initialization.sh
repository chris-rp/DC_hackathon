# This will run in unix, so if it fails for any reason ensure unix line endings
# Wait to be sure that SQL Server came up
sleep 30s

# Run the setup script to create the DB and the schema in the DB
# Note: make sure that your password matches what is in the Dockerfile
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P P4ssword -d master -i database-initialization.sql