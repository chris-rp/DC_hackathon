# This will run in unix, so if it fails for any reason ensure unix line endings
# Run Microsoft SQl Server and initialization script (at the same time)
/usr/src/app/run-initialization.sh & /opt/mssql/bin/sqlservr